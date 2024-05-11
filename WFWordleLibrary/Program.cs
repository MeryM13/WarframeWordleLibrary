using WFWordleLibrary;
using WFWordleLibrary.Game;
using WFWordleLibrary.JsonReaders;
using WFWordleLibrary.Model;
using WFWordleLibrary.Model.Database;
using WFWordleLibrary.WikiParser;

//database migration command
//Scaffold-DbContext "Data Source=localhost;Initial Catalog=WarframeWordle;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Model/Database" -ContextDir "Model"

using (var context = new WarframeWordleContext())
{
    //foreach (var item in context.Polarities)
    //{
    //    Console.WriteLine(item.PolarityName);
    //}

    // WikiParsers.ParseWarframeWikiToJson();

    //WarframeJsonParser parser = new(context);

    //context.Warframes.AddRange(parser.ParseWarframeList());
    //context.SaveChanges();
    Random rand = new Random();
    int tries = 0;
    int warframeCount = context.Warframes.Count();
    Warframe selected = context.Warframes.ElementAt(rand.Next(30));
    Warframe guess = new();
    do
    {
        Console.WriteLine("Enter a warframe name:");
        string name = Console.ReadLine();
        try
        {
            guess = context.Warframes.Where(x => x.Name == name).FirstOrDefault();

            if (guess == null)
                throw new Exception();

            var answer = AnswerHandling.GetWarframeAnswer(selected, guess);      
            foreach (var prop in answer.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {ReturnSymbol((AnswerTypes)prop.GetValue(answer, null))}");
            }
            Console.WriteLine();
        }
        catch
        (Exception ex)
        {
            Console.WriteLine("Not a valid name");
        }
        tries++;
    } while (selected != guess);
    Console.WriteLine($"Congratulations! You won in {tries} tries!");
    //context.Warframes.UpdateRange(parser.ParseWarframeList());
    //context.SaveChanges();
}

char ReturnSymbol(AnswerTypes answerType)
{
    switch (answerType)
    {
        case AnswerTypes.Correct:
            {
                return 'v';
            }
        case AnswerTypes.Wrong:
            {
                return 'x';
            }
        case AnswerTypes.Semicorrect:
            {
                return '-';
            }
            case AnswerTypes.Higher:
            {
                return '↑';
            }
            case AnswerTypes.Lower:
            {
                return '↓';
            }
            default:
            {
                return ' ';
            }
    }
}
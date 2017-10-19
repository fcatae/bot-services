
Bot.Say($"Hello {User.Name}");

var answer = Bot.Ask("Do you want to do something?");

if( answer == "yes" )
{
    Bot.Answer("YEAH!");
    Bot.Answer("Let's do it");
}

if( Language(answer) == "yes" )
{
    Bot.Answer("Yes please!");
}

if( Bot.PendingAnswer )
    Bot.Say("I don't understand")

////////////////////////////////////////////////////////////

// External

Database.Insert({ c1 = "", c2 = "" });
Http.Get("/api/search");

Checkpoint({ Picture = pic });

////////////////////////////////////////////////////////////


[Retry(3)]
Dialog Question1() {
    var answer = Bot.Ask("Do you want to do something?");

    if( Answer == "noo" )
    {
        return Dialog.Fail();
    }

    if( Answer == "yes" )
    {
        Bot.Answer("YEAH!");
    }

    if( Luis.Intent(answer) == "yes" )
    {
        Bot.Answer("Yes please!");
    }

    return Dialog.Ok({Answer = answer});
}

[Retry(3)]
Dialog ChooseProduct() {

    var answer = Luis.Ask("Which product: food, shoes, flowers?");

    switch( answer ) 
    {
        case "food":
            return Dialog.Call("food.csx");

        case "shoes":
            return Dialog.Goto("shoes.csx");

        case "flowers":
            // ask more
            var flower = Bot.Ask("Name a flower");

            if( flower == "rose" )
            {
                Bot.Say("Good choice");
            }
            else
            {
                Bot.Say("Ok");
            }
            return Dialog.Ok({ Flower = flower });

        case "none":
            return Dialog.Back();            
    }

}


// Start
var intent = Luis.Listen();

switch( intent )
{
    case "eat":
        Dialog.Call("eat.csx");
    case "drink":
        Dialog.Call("drink.csx");
    case "money":
        Dialog.Call("money.csx");
    case "picture":
        Dialog.Call(PictureDialog);    
}

Bot.Say("Goodbye")


Dialog PictureDialog() 
{
    var pic = Bot.Ask("Send a picture to authenticate");

    var face = FaceApi.Ask("Send a picture");
}

choose_product:
    var answerProd = Bot.Ask("Which product: food, shoes, flowers?");

    var answer = Luis.Ask("Which product: food, shoes, flowers?");

    switch( answer ) 
    {
        case "food":
            Dialog.Call("food.csx");
            break;

        case "shoes":
            Dialog.Goto("shoes.csx");
            break;

        case "flowers":
            var flower = Bot.Ask("Name a flower");

            if( flower == "rose" )
            {
                Bot.Say("Good choice");
            }
            else
            {
                Bot.Say("Ok");
            }

            break;

        case "none":
            Dialog.Back();
            break;
    }


    if( Bot.Check( answer == "yes" ))
    {
        Bot.Say("YEAH!");
        Bot.Say("Let's do it");
        Bot.Ok();
    }

    if( Language(answer) == "yes" )
    {
        Bot.Say("Yes please!");
        Bot.Ok();
    }



if( Bot.IsConfused )
    Bot.RetryAgain("Please answer yes or no", retries: 3);




Bot.Say($"Hello {Client.Name}");

using(var answer = await Bot.Ask("Do you want to do something?"))
{
    if( answer == "yes" )
    {
        Bot.Say("YEAH!");
        Bot.Say("Let's do it");
    }

    if( Language(answer) == "yes" )
    {
        Bot.Say("Yes please!");
    }

    if( Bot.IsConfused )
        Bot.RetryAsk("Please answer yes or no", retries: 3);

    if( answer.IsInvalid )
        Bot.RetryAgain("Please answer yes or no", retries: 3);

    answer.Invalid();
}


var pic = Bot.AskImage("Please send a picture");

if( pic == null )
    Bot.AskRetry();

Data.Picture = pic;




Bot.Say($"Hello {Client.Name}");

initial:
    var answer = Bot.Ask("Do you want to do something?");

    if( Answer == "yes" )
    {
        Bot.Answer("YEAH!");
    }

    if( Luis.Intent(answer) == "yes" )
    {
        Bot.Answer("Yes please!");
    }

    if( Bot.Retry(3) )
        goto initial;

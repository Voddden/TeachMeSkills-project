var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions { WebRootPath = "html" });
var app = builder.Build();

app.UseStaticFiles();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    if (context.Request.Path == "/reply-index2")
    {
        var form = context.Request.Form;

        string[] answer = new string[9];
        for (int i = 0; i < 9; ++i)
        {
            answer[i] = form["answer" + (i + 1)];
        }

        await context.Response.SendFileAsync("wwwroot/reply-index2_header.html");
        await context.Response.WriteAsync("<h3>Ваши ответы на форму:</h3>");
        for (int i = 0; i < 9; ++i)
        {
            await context.Response.WriteAsync($"<div>{i+1}) {answer[i]}</div>");
        }
        await context.Response.SendFileAsync("wwwroot/reply-index2.html");
    }
    else if (context.Request.Path == "/reply-index4")
    {
        // ответ на запрос о помощи

        var form = context.Request.Form;

        string[] answer = new string[3];
        for (int i = 0; i < 3; ++i)
        {
            answer[i] = form["answer" + (i + 1)];
        }


        await context.Response.SendFileAsync("wwwroot/reply-index4_header.html");
        // ответы на форму
        for (int i = 0; i < 3; ++i)
        {
            await context.Response.WriteAsync($"<label>{i + 1}) {answer[i]}</label>");
        }
        await context.Response.SendFileAsync("wwwroot/reply-index4.html");
    }
    else
    {
        await context.Response.SendFileAsync("wwwroot/index1-mainpage.html");
    }

});

app.Run();

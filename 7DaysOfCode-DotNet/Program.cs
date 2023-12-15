using _7DaysOfCode_DotNet.Controller;
using _7DaysOfCode_DotNet.View;


try
{
    MascoteView mascoteView = new MascoteView();
    mascoteView.Saudacao();
    mascoteView.SaltarLinha();

    string nome = mascoteView.Input("Qual é o seu nome?");
    await MascoteController.Jogar(mascoteView, nome);

}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}


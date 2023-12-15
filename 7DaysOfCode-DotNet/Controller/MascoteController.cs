using _7DaysOfCode_DotNet.Model;
using _7DaysOfCode_DotNet.Service;
using _7DaysOfCode_DotNet.View;

namespace _7DaysOfCode_DotNet.Controller
{
    public class MascoteController
    {
        public static async Task
        Jogar(MascoteView mascoteView, string nome)
        {
            IList<Mascote> mascotes = new List<Mascote>();
            MascoteService mascoteService = new MascoteService();

            string opcao = "1";

            while (opcao != "3")
            {
                mascoteView.SaltarLinha();
                opcao = mascoteView.Opcoes(nome);

                switch (opcao)
                {
                    case "1":
                        var listMascotes = await mascoteService.getAllAsync();
                        Results result = mascoteView.MenuAdotar(listMascotes);

                        var mascote = mascoteService.getAllById(result.url);
                        mascoteView.ExibirMascote(mascote);

                        if (mascoteView.InputConfirmacao("Tem certeza que deseja escolher esse mascote? (1 - Sim | 2 - Não)")) mascotes.Add(mascote);

                        break;
                    case "2":
                        mascoteView.MeusMascotes(mascotes);
                        string delete = mascoteView.Input("Caso deseja remover algum Mascote, pressione o número, para sair aperte 0");
                        if (delete != "0")
                        {
                            mascotes.Remove(mascotes[1 - Convert.ToInt16(delete)]);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Até Breve!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}

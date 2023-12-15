using _7DaysOfCode_DotNet.Model;

namespace _7DaysOfCode_DotNet.View
{
    public class MascoteView
    {

        public void Saudacao()
        {
            Console.WriteLine("Pokemon");
        }

        public void SaltarLinha()
        {
            Console.WriteLine("");
        }

        public string Opcoes(string nome)
        {
            Console.WriteLine(nome + ": O que deseja fazer?");
            Console.WriteLine("1 - Adotar mascote");
            Console.WriteLine("2 - Meus mascotes");
            Console.WriteLine("3 - Sair");
            return Console.ReadLine();
        }

        public Results MenuAdotar(Application application)
        {
            this.SaltarLinha();
            Console.WriteLine("Escolha um mascote:");

            var mascotes = application.results;
            for (int i = 0; i < mascotes.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + mascotes[i].name);
            }

            string opcaoMascoteStr = Console.ReadLine();

            if (int.TryParse(opcaoMascoteStr, out int opcaoMascote) && opcaoMascote >= 1 && opcaoMascote <= 20)
            {
                Results? result = mascotes[opcaoMascote - 1];

                if (result == null)
                {
                    Console.WriteLine("Verifique o ID do seu Mascote");
                    result = this.MenuAdotar(application);
                }

                return result;
            }
            else
            {
                Console.WriteLine("Campo inválido. Escolha um número entre 1 e 20.");
                return this.MenuAdotar(application);
            }
        }

        public void MeusMascotes(IList<Mascote> mascotes)
        {
            this.SaltarLinha();
            Console.WriteLine("Mascotes:");
            for (int i = 0; i < mascotes.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + mascotes[i].name.ToUpperInvariant());
            }
        }

        public void ExibirMascote(Mascote mascote)
        {
            this.SaltarLinha();
            Console.WriteLine("Nome: " + mascote.name.ToUpperInvariant());
            Console.WriteLine("Altura: " + mascote.height);
            Console.WriteLine("Peso: " + mascote.weight);
            Console.WriteLine("Habilidates: ");
            foreach (var item in mascote.Abilities)
            {
                Console.WriteLine(item.Ability.name);
            }
        }
        public string Input(string label)
        {
            Console.WriteLine(label);
            string value = Console.ReadLine();
            if (value == "")
            {
                Console.WriteLine("Campo obrigatório");
                value = this.Input(label);
            }
            return value;
        }

        public bool InputConfirmacao(string label)
        {
            bool retorno = false;
            bool loop = true;
            Console.WriteLine(label);
            string opcao = Console.ReadLine();
            while (loop)
            {
                switch (opcao)
                {
                    case "1":
                        retorno = true;
                        loop = false;
                        break;
                    case "2":
                        retorno = false;
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        retorno = this.InputConfirmacao(label);
                        if (retorno) loop = false;
                        break;
                }
            }
            return retorno;
        }

    }
}

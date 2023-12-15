using _7DaysOfCode_DotNet.Model;
using Newtonsoft.Json;
using RestSharp;

namespace _7DaysOfCode_DotNet.Service
{
    public class MascoteService
    {
        private RestClient client;
        private RestRequest request;


        private void _setMascoteService(string url, Method method)
        {
            this.client = new RestClient(url);
            this.request = new RestRequest(url, method);
        }

        public async Task<Application> getAllAsync()
        {
            try
            {
                this._setMascoteService("https://pokeapi.co/api/v2/pokemon", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);
                Application application = new Application();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    application = JsonConvert.DeserializeObject<Application>(response.Content);

                return application;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar: " + ex.Message);
            }
        }

        public Mascote getAllById(string url)
        {
            try
            {
                this._setMascoteService(url, Method.Get);
                RestResponse response = client.Execute(request);
                Mascote application = new Mascote();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    application = JsonConvert.DeserializeObject<Mascote>(response.Content);

                return application;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar: " + ex.Message);
            }
        }

    }
}

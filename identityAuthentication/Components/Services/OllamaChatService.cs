using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace identityAuthentication.Services
{
    // --- Modelos para a Resposta do Ollama ---
    // Usado para desserializar a resposta da API /api/generate
    public class OllamaGenerateResponse
    {
        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("done")]
        public bool Done { get; set; }
    }

    // --- Modelo para a Requisição para o Ollama ---
    public class OllamaGenerateRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("system")]
        public string System { get; set; } // O prompt do sistema

        [JsonPropertyName("stream")]
        public bool Stream { get; set; } = false; // Queremos a resposta de uma vez (sem stream)
    }


    /// <summary>
    /// Serviço para interagir com a API do Ollama (sem RAG, apenas chat simples).
    /// </summary>
    public class OllamaChatService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<OllamaChatService> _logger;
        private const string _ollamaModel = "llama3"; // Modelo que baixamos no Passo 1

        // O "System Prompt" define a personalidade e as regras do seu bot.
        private const string _systemPrompt = @"
            Você é o 'HelpBot', um assistente virtual amigável para um sistema de chamados de TI.
            Sua principal função é responder perguntas gerais sobre como usar o sistema.
            - Responda apenas sobre o sistema de chamados (abrir chamado, ver status, o que são categorias, etc.).
            - Se o usuário perguntar sobre qualquer outro assunto (programação, clima, história, etc.), 
              recuse educadamente dizendo: 'Desculpe, eu só posso ajudar com perguntas sobre o nosso sistema de chamados.'
            - Seja breve, amigável e direto ao ponto.
            - Responda em português brasileiro.";

        public OllamaChatService(IHttpClientFactory httpClientFactory, ILogger<OllamaChatService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Gera uma resposta simples do Ollama com base no prompt do usuário.
        /// </summary>
        public async Task<string> GerarRespostaSimplesAsync(string perguntaUsuario)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("Ollama");

                var requestPayload = new OllamaGenerateRequest
                {
                    Model = _ollamaModel,
                    Prompt = perguntaUsuario,
                    System = _systemPrompt
                };

                var response = await httpClient.PostAsJsonAsync("/api/generate", requestPayload);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Falha na API do Ollama: {StatusCode}", response.StatusCode);
                    return "Desculpe, não consigo me conectar ao assistente de IA no momento.";
                }

                var ollamaResponse = await response.Content.ReadFromJsonAsync<OllamaGenerateResponse>();
                
                return ollamaResponse?.Response ?? "Não obtive uma resposta válida.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar se comunicar com o Ollama.");
                // Mensagem de erro para o usuário (não expõe detalhes do erro)
                return "Ocorreu um erro ao processar sua solicitação de IA.";
            }
        }
    }
}
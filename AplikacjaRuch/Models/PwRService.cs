using System.Net.Http;
using System.Threading.Tasks;

public class PwRService
{
    private readonly HttpClient _client;

    public PwRService()
    {
        _client = new HttpClient();
    }

    public async Task<string> GiveMeAllRUCHWithFilledD1(string partnerId, string partnerKey, string city)
    {
        var content = new StringContent($@"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                            <GiveMeAllRUCHWithFilledD1 xmlns=""https://91.242.220.103/WebServicePwR"">
                              <PartnerID>{partnerId}</PartnerID>
                              <PartnerKey>{partnerKey}</PartnerKey>
                              <City>{city}</City>
                            </GiveMeAllRUCHWithFilledD1>
                          </soap:Body>
                        </soap:Envelope>");


        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
        var response = await _client.PostAsync("https://api-test.paczkawruchu.pl/WebServicePwR/WebServicePwR.asmx", content);

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GenerateLabelBusinessPack(string senderName, string receiverName, string pointId)
    {
        var content = new StringContent($@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                      <soap:Body>
                        <GenerateLabelBusinessPack xmlns=""https://91.242.220.103/WebServicePwR"">
                          <SenderName>{senderName}</SenderName>
                          <ReceiverName>{receiverName}</ReceiverName>
                          <PointId>{pointId}</PointId>
                        </GenerateLabelBusinessPack>
                      </soap:Body>
                    </soap:Envelope>");

        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
        var response = await _client.PostAsync("https://api-test.paczkawruchu.pl/WebServicePwR/WebServicePwR.asmx", content);

        return await response.Content.ReadAsStringAsync();
    }

}

using Client;

using (HttpClient client = new HttpClient())
{
    var uri = "https://localhost:7123";

    client.BaseAddress = new Uri(uri);


    await HttpService.Post(client);

    await HttpService.GetMethod(client);

    await HttpService.Delete(client);




}



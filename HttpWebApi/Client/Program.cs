using Client;
using System.Net.Http.Json;

using (HttpClient client = new HttpClient())
{
    // Set the base address if needed.
    var uri = "https://localhost:7123";

   


    HttpService.Post(client, uri);
    
   
}



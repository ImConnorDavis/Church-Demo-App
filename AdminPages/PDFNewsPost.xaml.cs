namespace Church_Demo.AdminPages;

using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using MongoDB.Bson;
using MongoDB.Driver;
using Syncfusion.PdfViewer;

public partial class PDFNewsPost : ContentPage
{
    //Stream pdfdatastream = new MemoryStream();
    Stream pdfdatastream = null;
	public PDFNewsPost()
	{
		InitializeComponent();
        On<iOS>().SetUseSafeArea(false);
        //pdfViewer.DocumentSource = "https://www.syncfusion.com/downloads/support/directtrac/general/pd/PDF_Succinctly1928776572";

    }

    async void ImportPDFBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        //PdfLoadedDocument document = null;
        try
        {
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                //Stream test = new MemoryStream();
                //test = await result.OpenReadAsync();
                pdfdatastream = await result.OpenReadAsync();
                pdfViewer.DocumentSource = pdfdatastream;
                pdfViewer.IsVisible = true;
                pdfViewer.IsEnabled = true;
            }
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
            Console.WriteLine("FAIL");
        }
    }
    async void PublishPDFBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        //byte[] pdfbytes = new byte[pdfdatastream.Length];
        //await pdfdatastream.ReadAsync(pdfbytes, 0, (int)pdfdatastream.Length);
        //pdfdatastream.Seek(0, SeekOrigin.Begin); // Reset the stream position
        //string pdfdata = System.Convert.ToBase64String(pdfbytes);

        //var settings = MongoClientSettings.FromConnectionString("mongodb://BeyondUnited:BrigandConnor@ac-kdudtc3-shard-00-00.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-01.9wr50hy.mongodb.net:27017,ac-kdudtc3-shard-00-02.9wr50hy.mongodb.net:27017/?ssl=true&replicaSet=atlas-5uj7c1-shard-0&authSource=admin&retryWrites=true&w=majority");
        //var client = new MongoClient(settings);
        //var database = client.GetDatabase("News");
        //var collection = database.GetCollection<BsonDocument>("News");
        //if (pdfdata != null)
        //{
        //    var document = new BsonDocument
        //        {
        //            {"pdfdata", pdfdata },
        //        };
        //    await collection.InsertOneAsync(document);
        //}
    }
}

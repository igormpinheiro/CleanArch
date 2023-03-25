using System.Drawing;



var barCode = "00198936700000220590000003091871000018010317";


foreach (var tipo in BarcodeLib.TYPE.GetValues(typeof(BarcodeLib.TYPE)))
{
    var arqDir = $"C:\\Temp\\teste_{tipo}.png";

    try
    {
        GerarImg(arqDir, barCode, (BarcodeLib.TYPE)tipo);
    }
    catch(Exception)
    {
        Console.WriteLine("deu ruim:" + tipo);
    }
    
    //Image img = b.Encode(BarcodeLib.TYPE.CODE128, barCode, Color.Black, Color.White, 290, 120);
    //var ms = new MemoryStream();
    //img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    //byte[] exportBytes = ms.ToArray();
    //ms.Close();


    //FileStream file = new FileStream(arqDir, FileMode.Create);
    //file.Write(exportBytes, 0, exportBytes.Length);
    //file.Close();
}




Console.ReadKey();

static void GerarImg(string arqDir, string barCode, BarcodeLib.TYPE tipo)
{
    BarcodeLib.Barcode b = new BarcodeLib.Barcode();
    Image img = b.Encode(tipo, barCode, Color.Black, Color.White);
    var ms = new MemoryStream();
    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    byte[] exportBytes = ms.ToArray();
    ms.Close();


    FileStream file = new FileStream(arqDir, FileMode.Create);
    file.Write(exportBytes, 0, exportBytes.Length);
    file.Close();

    //BarcodeLib.Barcode b = new BarcodeLib.Barcode();
    //b.IncludeLabel = true;
    //b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
    //b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
    //b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
    //b.LabelFont = new Font("Arial", 8);
    //b.BackColor = Color.White;
    //b.ForeColor = Color.Black;
    //b.Width = 300;
    //b.Height = 100;
    //b.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
    //b.Encode(tipo, barCode, Color.Black, Color.White, 300, 100);
    //b.SaveImage(arqDir, System.Drawing.Imaging.ImageFormat.Png);
}
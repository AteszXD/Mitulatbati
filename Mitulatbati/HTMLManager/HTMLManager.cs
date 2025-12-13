using Mitulatbati.SQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitulatbati.HTML
{
    class HTMLManager
    {
        /// <summary>
        /// Legenerálja a verseny állásának HTML oldalát
        /// </summary>
        /// <param name="competitors">A lista ami a versenyzőket tárolja</param>
        public void GenerateHTML(List<SQLManager> competitors)
        {
            string htmlStatic = "<!DOCTYPE html>\r\n<html lang=\"hu\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Kalaplengető verseny</title>\r\n    <link rel=\"stylesheet\" href=\"style.css\">\r\n</head>\r\n<body>\r\n\r\n    <div class=\"fade-in\">\r\n\r\n        <div class=\"header\">\r\n            <img src=\"szelesbalascimer.png\" alt=\"Szélesbálási címer\">\r\n            <img src=\"hurka.png\" alt=\"Szélesbálási címer\">\r\n            <span>Szélesbálási Fedettpályás Kalaplengető Verseny</span>\r\n            <img src=\"sor.png\" alt=\"Szélesbálási címer\">\r\n            <img src=\"szelesbalascimer.png\" alt=\"Szélesbálási címer\">\r\n        </div>\r\n\r\n        <table>\r\n            <thead>\r\n                <tr>\r\n                    <th>Helyezés</th>\r\n                    <th>Név</th>\r\n                    <th>Első pontszám</th>\r\n                    <th>Második pontszám</th>\r\n                    <th>Harmadik pontszám</th>\r\n                    <th>Legjobb pontszám</th>\r\n                </tr>\r\n                        </thead>\r\n            <tbody>";
            for (int i = 0; i < competitors.Count(); i++)
            {
                htmlStatic += $"\r\n                <tr>\r\n                    <td>{i + 1}</td>\r\n                    <td>{competitors[i].Name}</td>\r\n                    <td>{competitors[i].Elso_leng}</td>\r\n                    <td>{competitors[i].Masodik_leng}</td>\r\n                    <td>{competitors[i].Harmadik_leng}</td>\r\n                    <td>{competitors[i].Legjobb_leng}</td>\r\n                </tr>";
            }
            htmlStatic += "\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n\r\n</body>\r\n</html>";
        
            File.WriteAllText("verseny.html", htmlStatic);
        }
    }
}

using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqForXML.queries
{
    public class QueryForParseDataXml
    {
        private readonly XDocument _xDocument;

        internal QueryForParseDataXml(XDocument xDocument)
        {
            _xDocument = xDocument;
        }

        public void GetD()
        {
            var result = _xDocument.Descendants("дом").Select(home => home);
            foreach (var xElement in result)
            {
                Console.WriteLine($"- {xElement.Value}");
            }
        }

        /// <summary>
        /// Данные по всем жильцам
        /// </summary>
        public void PersonalData()
        {
            Console.WriteLine("\n1. Данные по всем жильцам обслуживаемых домов: ");
            var result = _xDocument
                .Descendants("жилец")
                .OrderBy(person => person.Element("фио")?.Value);
            Console.WriteLine($"|{"ФИО",15}{"",15}|{"Дата рождения",14}|");
            foreach (var r in result)
            {
                Console.WriteLine(
                    $"|{r.Element("фио")?.Value,30}" +
                    $"|{r.Element("дата_рождения")?.Value,14}|"
                );
            }
        }

        /// <summary>
        /// Расход воды и электроэнергии
        /// </summary>
        public void WaterAndElectricity()
        {
            Console.WriteLine("\n2. Суммарный расход воды и электроэнергии");
            if (_xDocument != null)
            {
                var result = _xDocument
                    .Descendants("показания_приборов")
                    .Select(doc => doc);
                double sumColWater = 0;
                double sumHotWater = 0;
                double sumElcPower = 0;
                foreach (var r in result)
                {
                    sumColWater += Convert.ToDouble(r.Element("холодная_вода")?.Value);
                    sumHotWater += Convert.ToDouble(r.Element("горячая_вода")?.Value);
                    sumElcPower += Convert.ToDouble(r.Element("эл_энергия")?.Value);
                }

                Console.WriteLine(
                    $"- Холодная вода: {sumColWater:f2} м3\n" +
                    $"- Горячая вода: {sumHotWater:f2} м3\n" +
                    $"- Электроэнергия: {sumElcPower:f2} м3\n"
                );
            }
        }

        /// <summary>
        /// Данные по квартирам расположенных в доме 8
        /// по улице Волгоградская
        /// </summary>
        public void ApartmentsData()
        {
            Console.WriteLine($"\n3. Данные по квартирам в доме 8, ул. Волгоградская: ");
            var result = _xDocument
                .Descendants("дом")
                .SelectMany(house =>
                    house.Elements("квартира"), (house, apartment) => new {house, apartment})
                .SelectMany(t =>
                    t.house.Elements("адрес"), (t, address) => new {t, address})
                .Where(t =>
                    t.address.Element("улица")?.Value == "Волгоградская" &&
                    t.address.Element("номер")?.Value == "8")
                .Select(t => t.t.apartment);
            Console.WriteLine(
                $"|{"Номер",6}" +
                $"|{"Площадь, м2",12}|"
            );
            foreach (var r in result)
            {
                Console.WriteLine(
                    $"|{r.Attribute("номер")?.Value,6}" +
                    $"|{r.Element("площадь")?.Value,12}|"
                );
            }
        }

        /// <summary>
        /// Число квартир, в которых расход горячей воды < 100 m3
        /// или расход электроэнергии < 120 квт/ч
        /// </summary>
        public void NumApartments()
        {
            Console.WriteLine("\n4. Число кварир с расходом горячей воды < 100 м3" +
                              " или расходом электроэнергии < 120 квт/ч: ");
            var result = _xDocument
                .Descendants("квартира")
                .SelectMany(apartment => apartment.Elements("показания_приборов"),
                    (apartment, appliance) => new {apartment, appliance})
                .Where(t =>
                    Convert.ToDouble(t.appliance.Element("горячая_вода")?.Value) < 100 ||
                    Convert.ToDouble(t.appliance.Element("эл_энергия")?.Value) < 120)
                .Select(t => t.apartment);
            int numAp = result.Count();
            Console.WriteLine($"- {numAp}");
        }

        public void Apartments30M()
        {
            Console.WriteLine("\n5. Квартиры с площадью более 30 м2 (сгруп. по домам): ");
            if (_xDocument != null)
            {
                var groups = _xDocument
                    .Descendants("дом")
                    .SelectMany(house => house.Elements("квартира"), (house, apartment) => new {house, apartment})
                    .Where(@t => (int) @t.apartment.Element("площадь") < 30)
                    .GroupBy(@t => @t.house.Attribute("код"), @t => @t.apartment);
                foreach (var group in groups)
                {
                    Console.WriteLine($"Квартиры в доме {@group.Key}");
                    foreach (var element in @group)
                    {
                        Console.WriteLine($"- {element.Attribute("код")}, №{element.Attribute("номер")?.Value}");
                    }
                }
            }
        }
    }
}
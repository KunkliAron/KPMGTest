using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace exchangeRates
{
	[XmlRoot(ElementName = "Rate")]
	public class Rate
	{
		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }
		[XmlAttribute(AttributeName = "unit")]
		public string Unit { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "Day")]
	public class Day
	{
		[XmlElement(ElementName = "Rate")]
		public List<Rate> Rate { get; set; }
		[XmlAttribute(AttributeName = "date")]
		public string Date { get; set; }
	}

	[XmlRoot(ElementName = "MNBExchangeRates")]
	public class MNBExchangeRates
	{
		[XmlElement(ElementName = "Day")]
		public List<Day> Day { get; set; }
	}

}

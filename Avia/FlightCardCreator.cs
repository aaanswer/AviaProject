using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avia
{
    internal class FlightCardCreator
    {
        public FlightCardCreator() { }
        public flightPanel createCard(string airline, string origin, string destination, DateTime departureTime, DateTime arrivalTime) 
        {
            flightPanel newFlightPanel = new flightPanel();

            newFlightPanel.headerLabel.Content = airline + ": " + origin + " - " + destination;
            newFlightPanel.Originlabel.Content = origin;
            newFlightPanel.DestinationLabel.Content = destination;
            newFlightPanel.departureTimeLabel.Content = departureTime.ToString();
            newFlightPanel.arrivalTimeLabel.Content = arrivalTime.ToString();

            return newFlightPanel;
        }
    }
}

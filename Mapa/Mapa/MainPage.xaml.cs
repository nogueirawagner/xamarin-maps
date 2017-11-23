using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mapa
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      var mapSpan = MapSpan.FromCenterAndRadius(
        new Position(-16.282301, -48.9562948), Distance.FromKilometers(1));

      var mapa = new Map(mapSpan);
      mapa.MapType = MapType.Street;
      mapa.IsShowingUser = true;

      var cartorio = new Pin
      {
        Position = new Position(-16.2815423, -48.955064),
        Label = "Drogaria Pirineus",
        Address = "Avenida dos Pirineus Quadra 5 Lote 2 - Parque dos Pirineus, Anápolis - GO, 75071-600",
        Type = PinType.Generic
      };

      var kitbeer = new Pin
      {
        Position = new Position(-16.2820019, -48.9564487),
        Label = "Megafer Materiais Para Construção e Ferragista",
        Address = "Avenida 10 Qd 32 Lt 20 - Jardim Progresso, Anápolis - GO, 75063-425",
        Type = PinType.Place
      };

      var oficina = new Pin
      {
        Position = new Position(-16.2829648, -48.9562382),
        Label = "GT CAR MANUTENÇÃO AUTOMOTIVA",
        Address = "QUADRA 34, LOTE 12, R. Tupi, 735 - Village Jardim, Anápolis - GO, 75063-735",
        Type = PinType.SavedPin
      };

      mapa.Pins.Add(cartorio);
      mapa.Pins.Add(kitbeer);
      mapa.Pins.Add(oficina);

      ContainerMapa.Children.Add(mapa);

    }
  }
}


﻿using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;

namespace Mapa
{
  public class GPS
  {
    public bool IsLocationAvailable()
    {
      if (!CrossGeolocator.IsSupported)
        return false;

      return CrossGeolocator.Current.IsGeolocationAvailable;
    }

    public async Task<Position> GetCurrentLocation()
    {
      Position position = null;
      try
      {
        var locator = CrossGeolocator.Current;
        locator.DesiredAccuracy = 100;

        position = await locator.GetLastKnownLocationAsync();

        if (position != null)
        {
          //got a cahched position, so let's use it.
          return position;
        }

        if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
        {
          //not available or enabled
          return position;
        }

        position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

      }
      catch (Exception ex)
      {
        //Display error as we have timed out or can't get location.
      }

      if (position == null)
        return position;

      return position;
    }
  }
}

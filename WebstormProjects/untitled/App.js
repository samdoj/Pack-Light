/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
    Button,
    Image,
    Platform,
    TouchableHighlight,
    StyleSheet,
    Text,
    View, WebView
} from 'react-native';
import MapView  from 'react-native-maps';
import { Vibration } from "react-native";

export default class App extends Component<{}> {
constructor ()
{
  super();
    let options = {
        enableHighAccuracy: true,
        timeout: 100,
        maximumAge: 1000
    };
  navigator.geolocation.watchPosition((location)=>{
    const js = "mymap.removeLayer(mylayer);"+
        "mylayer = new L.LayerGroup()"+
        `mypos = L.marker([${location.coords.latitude}, ${location.coords.longitude}]).addTo(mylayer).bindPopup("<b>You are here!").openPopup();`+
        "mylayer.addTo(mymap);}"
      alert(js)
      this.refs.webview.injectJavaScript(js)
      alert(`latitude: ${location.coords.latitude}\n\`longitude: ${location.coords.longitude}
`)
      },
      (err)=>{alert(JSON.stringify(err))}, options)

    this.state = {
        region: null,
        lat: 0,
        long: 0,

  }


}
    onRegionChange(region) {
        this.setState({region}, )
    }
  render() {
     setTimeout(()=> navigator.geolocation.getCurrentPosition((location)=>{{this.refs.webview.injectJavaScript(`mypos = L.marker([${location.latitude}.lat,${location.longitude}]).update(mypos);`)}}), 1500);
   //   <Image source = {require('./assets/dog-icon-45956@2x.png')} style={{resizeMode:'stretch'}}>

  //</Image>
      Vibration.vibrate(1000)
      return (

        <View style={{flex:1}}>

            <WebView source={{uri:'https://seawolf.ca/2017-hackathon/as/Where2CR.html'}}
                     javaScriptEnabledAndroid={true}
                     style={{flex:1,backgroundColor:'blue',marginTop:0}} ref="webview"
                     scalesPageToFit={true}
            />

        </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 50,
      color:"purple",
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

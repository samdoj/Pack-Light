/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
    Platform, ScrollView,
    StyleSheet,
    Text,
    View,
    WebView
} from 'react-native';

export default class App extends Component<{}> {

  render() {
  setTimeout(()=> {this.refs.webview.injectJavaScript("mymap.panTo(new L.LatLng(40.737, -73.923));")},5000)
    return (
        <View style={{flex: 1, flexDirection:'column'}}>
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
    flex: 5,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

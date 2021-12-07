import 'react-native-gesture-handler';

import React, {Component} from 'react';

import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';

import {StatusBar, StyleSheet} from 'react-native';

import Login from './src/screens/login/login'
import listarMED from './src/screens/ListarMED/listarMed';

const AuthStack = createStackNavigator();

class App extends Component {
    render() {
      return(
        <NavigationContainer>
        <StatusBar
          hidden={true}
        />
        <AuthStack.Navigator
          screenOptions={{
            headerShown: false,
          }}>
          <AuthStack.Screen name="Login" component={Login} />
          <AuthStack.Screen name="listarMED" component={listarMED} />
        </AuthStack.Navigator>
      </NavigationContainer>
      );
    }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1',
  }
});

export default App;

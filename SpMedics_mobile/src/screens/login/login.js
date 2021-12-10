import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../../services/api';
import App from '../../../App';
import jwtDecode from 'jwt-decode';


export default class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            // login Med: 'roberto.possarle@spmedicalgroup.com.br' 'possarle'
            // Login Pac: 'fernando@gmail.com','fernando'
        };
    }

    realizarLogin = async () => {
        console.warn(this.state.email + ' ' + this.state.senha);

        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha,
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if ((resposta.status == 200) && (jwtDecode(token).role === "2")) {
                this.props.navigation.navigate('listarPAC');
        }else if ((resposta.status == 200) && (jwtDecode(token).role === "3")) {
                this.props.navigation.navigate('listarMED');
        }
        console.warn(token);
        
    };

    render() {
        return (
            <ImageBackground
                style= {StyleSheet.absoluteFillObject}>
                <View style={styles.fundoVerde}  />
                <View style={styles.main} >
                    <Image
                        source={require('../../../assets/img/Frame_1-removebg-preview.png')}
                        style={styles.logoLogin}
                    />

            <TextInput
                style={styles.inputLogin}
                placeholder="email:"
                placeholderTextColor="#C4C4C4"
                textAlign="left"
                keyboardType="email-address"
                onChangeText={email => this.setState({email})}
            />

            <TextInput
                style={styles.inputLogin}
                placeholder="senha:"
                textAlign="left"
                placeholderTextColor="#C4C4C4"
                keyboardType="default"
                secureTextEntry={true}
                onChangeText={senha => this.setState({senha})}
            />
            
            <TouchableOpacity
                style={styles.btnLogin}
                onPress={this.realizarLogin}
            >
                <Text style={styles.btnLoginText}>Login</Text>
                
            </TouchableOpacity>

            <Text
            style={styles.Texto}>From Senai Informática</Text>

                </View>
            </ImageBackground>
        );
    };
};

    const styles = StyleSheet.create({
        main: {
            backgroundColor: '#88DD81',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
            height: '100%',
        },
        logoLogin: {
            width: 150,
            height: 137.6,
            marginBottom: 120
        },

        inputLogin: {
            width: 200,
            backgroundColor: '#FFF',
            borderRadius: 30,
            textAlign: 'center',
            marginBottom: 20
        },

        btnLogin: {
            width: 110,
            height: 40,
            backgroundColor: '#FFF',
            borderRadius: 30,
            textAlign: 'center',
            marginBottom: 20
        },

        btnLoginText: {
            marginLeft: 35,
            marginTop: 10,
            color: "#C4C4C4"
        },

        Texto: {
            color: "#50A849",
            marginTop: 100 
        }
});

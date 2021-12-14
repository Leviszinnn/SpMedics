import React, {Component} from 'react';
import {FlatList, Image, StyleSheet, Text, View} from 'react-native';

import api from '../../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class listarPAC extends Component {
    constructor(props) {
        super(props);
        this.state = {
            MyQueries: [],
        };
    }

    SearchMyQueries = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            // console.warn('token')
            // console.warn(token)

            const resposta = await api.get('/Consultum/minhas', {
                headers: {
                    Authorization: 'Bearer ' + token
                }
            });

            if (resposta.status === 200) {
                const ApiData = resposta.data;
                this.setState({MyQueries: ApiData})
            }
        } catch (error) {
            console.warn(error);
        }
    };

    componentDidMount() {
        this.SearchMyQueries();
    }

    render() {
        return(
            <View style={styles.main}>
                <Text style={styles.H1}>{"SpMedicals Group: Pacientes"}</Text>
                <FlatList
                contentContainerStyle={styles.styleFlat}
                data={this.state.MyQueries}
                keyExtractor={item => item.idConsulta}
                renderItem={this.renderItem} />
                <Image
                    source={require('../../../assets/img/Frame_1-removebg-preview.png')}
                    style={styles.logoSP}
                />
            </View>
        );
    }

    renderItem = ({item}) => (
    
        <View style={styles.flatItemRow}>
          <View style={styles.flatItemContainer}>
            <Text style={styles.flatItemInfo}>{"Médico: "}</Text>
            <Text style={styles.flatItemInfo}>{"Data: " + item.dataConsulta}</Text>
            <Text style={styles.flatItemInfo}>{"Descrição: " + item.descConsulta}</Text>
            <Text style={styles.flatItemInfo}>{"Situação: "}</Text>
          </View>
        </View>
      );
    }

    const styles = StyleSheet.create ({
        main: {
            backgroundColor: '#88DD81',
            justifyContent: 'center',
            alignItems: 'center',
            width: '100%',
            height: '100%',
        },

        H1: {
            color: '#000',
            fontSize: 20,
            marginTop: 45,
            marginBottom: 40
        },

        flatItemContainer: {
            backgroundColor: '#fff',
            borderRadius: 10,
            width:285,
            marginBottom: 20,
            height:102,
            justifyContent: 'center'
        },

        flatItemInfo: {
            textAlign: 'left',
            marginLeft: 20,
        },

        logoSP: {
            width: 150,
            height: 137.6,
            marginBottom: 70
        }
    });

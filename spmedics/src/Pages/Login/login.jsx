import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import logo from '../../assets/img/logo_preto 1.png'

import'../../assets/css/login.css';


export default class login extends Component { 
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            mensagemerro: '',
            isLoading: False
        };
    };


    efetuaLogin = (event) => {
        event.preventDefault();
        this.setState({ mensagemerro: '', isLoading: True});

        axios.post('http://5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha
        })

    .then(resposta => {
        if (resposta.status === 200) {
            localStorage.setItem('usuario-login', resposta.data.token);
            this.setState({isLoading: false});

            let base64 = localStorage.getItem('usuario-login').split('.')[1];
            console.log(base64);

            console.log(this.props)
        }
    })
};

    atualizaStateCampo = (campo) => {
        this.setState({[campo.target.name]: campo.target.value})
    };

    render(){
        return(
        <div>
            <div className="container header">
                <img className="logo-spmed" src={logo} />
                <nav id="itens" class="links">
                    <a href="">Home</a>
                    <a href="">Sobre</a>
                    <a href="">Login</a>
                </nav>
            </div>
        <main>
            <div className="fundo">
            <div className="background">
                <div className="quadro">
                    <img className="logo-saopaulomed" src={logo}/>
                    <div className="inputs-login">
                        <span className="spanquadro">E-mail:</span>
                        <input 
                            type="email" 
                            className="inputs"
                            name='email'
                            value={this.state.email}
                            onChange={this.atualizaStateCampo}
                            placeholder='email:'
                        />
                        <span className="spansenha">Senha:</span>
                        <input
                            type="password"
                            className="inputs" 
                            name='senha' 
                            value={this.state.senha} 
                            onChange={this.atualizaStateCampo} 
                            placeholder='password:'
                        />
                    </div>
                    <div className="botoesQuadro"/>
                        <button class="btn-login">Cadastrar-se</button>
                        <button class="btn-login" onSubmit={this.efetuaLogin}>Login</button>
                    </div>
                </div>
            </div>
        </main>
            <div className="container footer">
                <img className="logo-footer" src={logo}/>
            </div>
        </div>
        )
    }
};

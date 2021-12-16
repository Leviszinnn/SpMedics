import { Component } from "react";
import axios from "axios";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        };
    };

    realizaLogin = (event) => {
        event.preventDefault();

        axios.post('http://192.168.7.27:5000/api/Login', 
        {   
            email: this.state.email,
            senha: this.state.senha
        })  
        .then(resposta => {
            if (resposta.status === 200) {
                console.log(resposta.data.token)
                localStorage.setItem('user-login', resposta.data.token)
            }
        })
    }

    attState = (campo) => {
        this.setState({[campo.target.name]: campo.target.value})
    };

    render(){
        return(
            <div>
                <main>
                    <section>
                        <form onSubmit={this.realizaLogin}>
                            <input
                            type="text"
                            name="email"
                            value={this.state.email}
                            onChange={this.attState}
                            placeholder="email"
                            />

                            <input
                            type="password"
                            name="senha"
                            value={this.state.senha}
                            onChange={this.attState}
                            placeholder="senha"
                            />

                            <button type="submit">
                                Login
                            </button>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
}


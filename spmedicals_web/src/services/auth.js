export const usuarioLogado = () => localStorage.getItem('user-login') !== null;

export const parseJwt = () => {
    let base64 = localStorage.getItem('user-login').split('.')[1];
    return JSON.parse(window.atob(base64));
}
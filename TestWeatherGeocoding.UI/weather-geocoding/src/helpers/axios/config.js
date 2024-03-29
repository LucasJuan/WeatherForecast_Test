import axios from 'axios';
const uri =process.env.REACT_APP_LINK_API
debugger
const instance = axios.create({
  baseURL: uri,
  headers: {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'grant_type': 'client_credentials',
  },
});

instance.interceptors.response.use(
  response => response,
  error => {
    if (error.response && error.response.status === 404) {
      return Promise.resolve(error.response);
    }
    return Promise.reject(error);
  }
);

export default instance;
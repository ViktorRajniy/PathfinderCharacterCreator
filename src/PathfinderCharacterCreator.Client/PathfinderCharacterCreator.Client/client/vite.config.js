import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
	plugins: [react()],
    //server: {
    //    proxy: {
    //        'http://localhost:5233/api/User/test/get': {
    //            target: 'https://localhost:7160/api/User/test/get',
    //            changeOrigin: true,
    //            secure: true,
    //            // target: process.env.REACT_APP_API_URL,
    //            // changeOrigin: true,
    //            // secure: false,
    //            ws: true,
    //            xfwd: true,
    //            autoRewrite: true,
    //            followRedirects: true,
    //             configure: (proxy, options) => {
    //               console.log('proxy!!!!!!!!');
    //               // proxy will be an instance of 'http-proxy'
    //             },
    //        },
    //    },
    //},
})

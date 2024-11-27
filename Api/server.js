//Instanciar rutas
var colorDeVehiculoRoute = require('./src/routes/colorDeVehiculoRoute');
var informeRoute = require('./src/routes/informeRoute');
var marcaDeVehiculoRoute = require('./src/routes/marcaDeVehiculoRoute');
var personalRoute = require('./src/routes/personalRoute');
var regDeEmpleadoRoute = require('./src/routes/regDeEmpleadoRoute')
var regDeTipoLavadoRoute = require('./src/routes/regDeTipoLavadoRoute')
var regDeVehiculoRoute = require('./src/routes/regDeVehiculoRoute')
var serviciosRoute = require('./src/routes/serviciosRoute')
var tipoDePagoRoute = require('./src/routes/tipoDePagoRoute')
var tipoDeVehiculoRoute = require('./src/routes/tipoDeVehiculoRoute')
var usuarioRoute = require('./src/routes/usuarioRoute');

//Configuracion de BD
const express = require('express')
const app = express()
require('./src/bd/db')
app.set('port', process.env.PORT || 3000)

//Middlewares
app.use(express.json())

//Usar rutas
app.use('/api', colorDeVehiculoRoute)
app.use('/api', informeRoute)
app.use('/api', marcaDeVehiculoRoute)
app.use('/api', personalRoute)
app.use('/api', regDeEmpleadoRoute)
app.use('/api', regDeTipoLavadoRoute)
app.use('/api', regDeVehiculoRoute)
app.use('/api', serviciosRoute)
app.use('/api', tipoDePagoRoute)
app.use('/api', tipoDeVehiculoRoute)
app.use('/api', usuarioRoute)

//Escuchar servicio
app.listen(app.get('port'), (error) => {
    if (error) {
        console.log(`Sucedió un error: ${error}`);
    }else{
        console.log(`Servidor corriendo en el puerto: ${app.get('port')}`);
    }
});
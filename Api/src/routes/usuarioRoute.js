'use strict'
const { Router } = require('express');
const api = Router();
var usuarioController = require('../controllers/usuarioController');


api.post('/seleccionar_usuario/', usuarioController.seleccionar_usuario);
api.get('/seleccionar_listaUsuarios/:ide', usuarioController.seleccionar_listaUsuarios);
api.get('/seleccionar_usuarioPorCorreo/:correo', usuarioController.seleccionar_usuarioPorCorreo);
api.put('/actualizar_usuario/:id', usuarioController.actualizar_usuario);
api.post('/insertar_usuario/', usuarioController.insertar_usuario);
api.delete('/eliminar_usuario/:id', usuarioController.eliminar_usuario);

module.exports = api;
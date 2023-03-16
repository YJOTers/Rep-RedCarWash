'use strict'
const { Router } = require('express');
const api = Router();
var regDeEmpleadoController = require('../controllers/regDeEmpleadoController');

api.get('/seleccionar_regDeEmpleado/:ide', regDeEmpleadoController.seleccionar_regDeEmpleado);
api.put('/actualizar_regDeEmpleado/:id', regDeEmpleadoController.actualizar_regDeEmpleado);
api.post('/insertar_regDeEmpleado/', regDeEmpleadoController.insertar_regDeEmpleado);
api.delete('/eliminar_regDeEmpleado/:id', regDeEmpleadoController.eliminar_regDeEmpleado);

module.exports = api;
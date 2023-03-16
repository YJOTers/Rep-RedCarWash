'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar registro de empleado
const seleccionar_regDeEmpleado = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM registro_de_empleado WHERE id_uc_re = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar registro de empleado
const actualizar_regDeEmpleado = async function(req, res){
    const id = req.params.id; 
    const sql = `UPDATE registro_de_empleado SET ${connection.escape(req.body)} WHERE id_re = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar registro de empleado
const insertar_regDeEmpleado = async function(req, res){
    const sql = `INSERT INTO registro_de_empleado SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar registro de empleado
const eliminar_regDeEmpleado = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM registro_de_empleado WHERE id_re = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_regDeEmpleado,
    actualizar_regDeEmpleado,
    insertar_regDeEmpleado,
    eliminar_regDeEmpleado
};
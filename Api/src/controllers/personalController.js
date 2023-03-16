'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar personal
const seleccionar_personal = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM vista_personal WHERE id_uc_personal = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar personal
const actualizar_personal = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE personal SET ${connection.escape(req.body)} WHERE id_personal = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar personal
const insertar_personal = async function(req, res){
    const sql = `INSERT INTO personal SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar personal
const eliminar_personal = async function(req, res){
    const id = req.params.id; 
    const sql = `DELETE FROM personal WHERE id_personal = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_personal,
    actualizar_personal,
    insertar_personal,
    eliminar_personal
};
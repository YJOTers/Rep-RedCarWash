'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar registro del tipo de lavado
const seleccionar_regDeTipoLavado = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM registro_de_tipo_lavado WHERE id_uc_rtl = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar registro del tipo de lavado
const actualizar_regDeTipoLavado = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE registro_de_tipo_lavado SET ${connection.escape(req.body)} WHERE id_rtl = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar registro del tipo de lavado
const insertar_regDeTipoLavado = async function(req, res){
    const sql = `INSERT INTO registro_de_tipo_lavado SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar registro del tipo de lavado
const eliminar_regDeTipoLavado = async function(req, res){
    const id = req.params.id; 
    const sql = `DELETE FROM registro_de_tipo_lavado WHERE id_rtl = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_regDeTipoLavado,
    actualizar_regDeTipoLavado,
    insertar_regDeTipoLavado,
    eliminar_regDeTipoLavado
};
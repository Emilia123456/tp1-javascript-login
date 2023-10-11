//necesitamos traer la contraseña
const contra = document.getElementById("contrasenia");
const boton =document.getElementById("boton");
boton.disabled=true

const especiales = [
    "!","#","$","%","&","/","@"
]

const mayúsculas = [
    "A","B","C","D","E","F","G","H","I","J","K","L","M","N","Ñ","O","P","Q","R","S","T","U","V","W","X","Y","Z"
]

contra.addEventListener("input", () => {
    let valor = contra.value 
    const tieneEspeciales = especiales.some(Caracter => valor.includes(Caracter))
    const tieneMayúsculas = mayúsculas.some(Caracter => valor.includes(Caracter))
    if(tieneEspeciales && tieneMayúsculas && valor.length >= 8){
        contra.style.border="2px solid green"
        boton.enabled = true
    }else{
        contra.style.border="2px solid red"
        
    }
})
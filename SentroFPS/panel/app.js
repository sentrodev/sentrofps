const $ = (q)=>document.querySelector(q);
const api = {
async getFile({owner,repo,path,branch,token}){
const r = await fetch(`https://api.github.com/repos/${owner}/${repo}/contents/${path}?ref=${branch}`, {
headers: token ? {Authorization:`Bearer ${token}`} : {}
});
if(!r.ok) throw new Error("GET " + r.status);
const j = await r.json();
return j; // { content (base64), sha }
},
async putFile({owner,repo,path,branch,token,content,sha}){
const body = {
message: `chore(panel): update ${path}`,
content: btoa(unescape(encodeURIComponent(content))),
branch,
sha
};
const r = await fetch(`https://api.github.com/repos/${owner}/${repo}/contents/${path}`,{
method:'PUT',
headers:{ 'Content-Type':'application/json', Authorization:`Bearer ${token}` },
body: JSON.stringify(body)
});
if(!r.ok) throw new Error("PUT " + r.status);
return await r.json();
}
};


let currentSha = null;


$('#load').onclick = async ()=>{
try{
$('#status').textContent = 'Chargement...';
const owner = $('#owner').value.trim();
const repo = $('#repo').value.trim();
const path = $('#path').value.trim();
const branch = $('#branch').value.trim();
const token = $('#token').value.trim();


const f = await api.getFile({owner,repo,path,branch,token});
currentSha = f.sha;
const raw = decodeURIComponent(escape(atob(f.content)));
$('#editor').value = raw;
$('#status').textContent = 'Chargé ✔';
}catch(e){ $('#status').textContent = 'Erreur: '+e.message; }
};


$('#save').onclick = async ()=>{
try{
$('#status').textContent = 'Sauvegarde...';
const owner = $('#owner').value.trim();
const repo = $('#repo').value.trim();
const path = $('#path').value.trim();
const branch = $('#branch').value.trim();
const token = $('#token').value.trim();


const content = $('#editor').value;
const res = await api.putFile({owner,repo,path,branch,token,content,sha:currentSha});
currentSha = res.content.sha;
$('#status').textContent = 'Sauvegardé ✔';
}catch(e){ $('#status').textContent = 'Erreur: '+e.message; }
};
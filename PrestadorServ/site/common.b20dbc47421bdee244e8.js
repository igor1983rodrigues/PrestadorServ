(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{HHm8:function(t,n,e){"use strict";e.d(n,"a",function(){return l});var u=e("qq/0"),r=e("CcnG"),i=e("t/Na"),l=function(){function t(t){var n=this;this.httpClient=t,this.getPathApiService=u.a.WEBAPI_URL+"/api/prestado",this.getAll=function(t){return n.httpClient.get(n.getPathApiService).subscribe(function(n){return t(n)},function(t){return alert(t.message)})},this.getList=function(t,e){return n.httpClient.get(n.getPathApiService,{params:t}).subscribe(function(t){return e(t)},function(t){return alert(t.message)})},this.getMelhoresClientesEstatistica=function(t){return n.httpClient.get(n.getPathApiService+"/maioresconsumidores").subscribe(function(n){return t(n)},function(t){return alert(t.message)})},this.getMediaFornecedorEstatistica=function(t){return n.httpClient.get(n.getPathApiService+"/mediafornecedorestiposervico").subscribe(function(n){return t(n)},function(t){return alert(t.message)})},this.getFornecedorSemResultadoEstatistica=function(t){return n.httpClient.get(n.getPathApiService+"/fornecedoressemresultado").subscribe(function(n){return t(n)},function(t){return alert(t.message)})},this.getById=function(t,e){return n.httpClient.get(n.getPathApiService+"/"+t).subscribe(function(t){return e(t)},function(t){return alert(t.message)})},this.inserir=function(t,e){return n.httpClient.post(n.getPathApiService,t).subscribe(function(t){return e(t)},function(t){return alert(t.message)})},this.alterar=function(t,e){return n.httpClient.put(n.getPathApiService+"/"+t.idServicoPrestado,t).subscribe(function(t){return e(t)},function(t){return alert(t.message)})},this.excluir=function(t,e){return n.httpClient.delete(n.getPathApiService+"/"+t).subscribe(function(t){return e(t)},function(t){return alert(t.message)})}}return t.ngInjectableDef=r.T({factory:function(){return new t(r.X(i.c))},token:t,providedIn:"root"}),t}()},PCNd:function(t,n,e){"use strict";e.d(n,"a",function(){return u});var u=function(){return function(){}}()},jHKW:function(t,n,e){"use strict";var u=e("CcnG"),r=e("Ip0R");e("nI09"),e.d(n,"a",function(){return i}),e.d(n,"b",function(){return c});var i=u.nb({encapsulation:0,styles:[[""]],data:{}});function l(t){return u.Jb(0,[(t()(),u.pb(0,0,null,null,1,"small",[],null,null,null,null,null)),(t()(),u.Hb(1,null,["",""]))],null,function(t,n){t(n,1,0,n.component.descricao)})}function c(t){return u.Jb(0,[(t()(),u.pb(0,0,null,null,5,"div",[["class","d-flex align-items-center p-3 my-3 text-white-50 bg-info rounded shadow-sm"]],null,null,null,null,null)),(t()(),u.pb(1,0,null,null,4,"div",[["class","lh-100"]],null,null,null,null,null)),(t()(),u.pb(2,0,null,null,1,"h6",[["class","h3 text-white"]],null,null,null,null,null)),(t()(),u.Hb(3,null,["",""])),(t()(),u.hb(16777216,null,null,1,null,l)),u.ob(5,16384,null,0,r.l,[u.P,u.M],{ngIf:[0,"ngIf"]},null)],function(t,n){t(n,5,0,!!n.component.descricao)},function(t,n){t(n,3,0,n.component.titulo||"\xa0")})}},nI09:function(t,n,e){"use strict";e.d(n,"a",function(){return u});var u=function(){function t(){this.titulo="",this.descricao=null}return t.prototype.ngOnInit=function(){},t}()},"qq/0":function(t,n,e){"use strict";e.d(n,"a",function(){return u});var u=function(){function t(){}return t.WEBAPI_URL="",t}()}}]);
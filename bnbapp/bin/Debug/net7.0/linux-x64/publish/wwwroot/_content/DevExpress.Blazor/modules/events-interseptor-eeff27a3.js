import{_ as e}from"./_tslib-6e8ca86b.js";import{e as t}from"./property-d3853089.js";import{n}from"./custom-element-bd7061f2.js";import{s as i}from"./lit-element-b0a6fcba.js";function s(e,t){return(({finisher:e,descriptor:t})=>(n,i)=>{var s;if(void 0===i){const i=null!==(s=n.originalKey)&&void 0!==s?s:n.key,r=null!=t?{kind:"method",placement:"prototype",key:i,descriptor:t(n.key)}:{...n,key:i};return null!=e&&(r.finisher=function(t){e(t,i)}),r}{const s=n.constructor;void 0!==t&&Object.defineProperty(n,i,t(i)),null==e||e(s,i)}})({descriptor:n=>{const i={get(){var t,n;return null!==(n=null===(t=this.renderRoot)||void 0===t?void 0:t.querySelector(e))&&void 0!==n?n:null},enumerable:!0,configurable:!0};if(t){const t="symbol"==typeof n?Symbol():"__"+n;i.get=function(){var n,i;return void 0===this[t]&&(this[t]=null!==(i=null===(n=this.renderRoot)||void 0===n?void 0:n.querySelector(e))&&void 0!==i?i:null),this[t]}}return i}})}const r="dxbl-events-interceptor";let l=class extends i{constructor(){super(),this.eventsSet=new Set,this.events=null,this.eventListener=this.handleEvent.bind(this),this._value=null}get value(){return this._value}updated(e){var t,n;e.has("events")&&(this.unsubscribe(null!==(t=e.get("events"))&&void 0!==t?t:null),this.eventsSet=new Set(null===(n=this.events)||void 0===n?void 0:n.split(";")),this.subscribe(this.events))}subscribe(e){var t;null===(t=this.events)||void 0===t||t.split(";").forEach((e=>{this.addEventListener(e,this.eventListener)}))}unsubscribe(e){null==e||e.split(";").forEach((e=>{this.removeEventListener(e,this.eventListener)}))}raise(e,t){try{if(!this.eventsSet.has(e))return;this._value=JSON.stringify([e,t]),this.dispatchEvent(new Event("change",{bubbles:!0}))}finally{this._value=null}}handleEvent(e){}};e([t({type:String,attribute:"events"})],l.prototype,"events",void 0),l=e([n("dxbl-events-interceptor")],l);export{r as d,s as i};
import{D as e}from"./dx-html-element-base-3902c3e3.js";import"./data-qa-utils-8be7c726.js";import"./dx-html-element-pointer-events-helper-0f2b6602.js";import"./dom-166a04be.js";import"./_tslib-6e8ca86b.js";import"./eventhelper-8570b930.js";var t;!function(e){e[e.Indeterminate=0]="Indeterminate",e[e.Checked=1]="Checked",e[e.Unchecked=2]="Unchecked"}(t||(t={}));class n extends e{constructor(){super(...arguments),this._checkState=t.Unchecked,this._allowIndeterminateStateByClick=!1,this.boundOnInputChangeHandler=this.onInputChange.bind(this)}get checkState(){return this._checkState}set checkState(e){this._checkState=e,this.applyCheckStateToInputElement()}get allowIndeterminateStateByClick(){return this._allowIndeterminateStateByClick}set allowIndeterminateStateByClick(e){this._allowIndeterminateStateByClick=e}initializeComponent(){super.initializeComponent(),this.getInputElement().addEventListener("change",this.boundOnInputChangeHandler)}disposeComponent(){var e;null===(e=this.getInputElement())||void 0===e||e.removeEventListener("change",this.boundOnInputChangeHandler),super.disposeComponent()}getInputElement(){return this.querySelector("input")}get value(){return this.checkState===t.Indeterminate?"":Boolean(this.checkState===t.Checked).toString()}getNextCheckState(){let e=this.checkState+1;return e>t.Unchecked&&(e=this.allowIndeterminateStateByClick?t.Indeterminate:t.Checked),e}onInputChange(e){this.checkState=this.getNextCheckState(),this.applyCheckStateToInputElement(),this.dispatchEvent(new Event("change",{bubbles:!0}))}applyCheckStateToInputElement(){const e=this.getInputElement();e&&(e.indeterminate=this.checkState===t.Indeterminate,e.checked=this.checkState===t.Checked)}static get observedAttributes(){return["check-state","allow-indeterminate-state-by-click"]}attributeChangedCallback(e,t,n){switch(e){case"check-state":this.checkState=Number(n);break;case"allow-indeterminate-state-by-click":this.allowIndeterminateStateByClick=null!==n}}}customElements.define("dxbl-check",n);const a={loadModule:function(){}};export{n as DxCheckInternal,a as default};

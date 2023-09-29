import{_ as e}from"./_tslib-6e8ca86b.js";import{B as t}from"./dom-166a04be.js";import o from"./adaptivedropdowncomponents-2a8022ab.js";import{D as r}from"./dx-dropdown-base3-84874f0e.js";import{ListBoxSelectedItemsChangedEvent as n}from"./dx-listbox-4e683ee8.js";import{C as s}from"./custom-events-helper-18f7786a.js";import{c as i}from"./constants-4c28185b.js";import{k as d}from"./key-59f0f3b5.js";import{e as p}from"./property-d3853089.js";import"./dropdowncomponents-f7289a07.js";import"./popup-99058cdb.js";import"./rect-7fc5c2ef.js";import"./point-9c6ab88a.js";import"./rafaction-bba7928b.js";import"./transformhelper-ebad0156.js";import"./layouthelper-4b19d191.js";import"./positiontracker-dba18a16.js";import"./branch-2ea85171.js";import"./custom-element-bd7061f2.js";import"./lit-element-b0a6fcba.js";import"./capturemanager-91fa2b2d.js";import"./eventhelper-8570b930.js";import"./logicaltreehelper-15991dcb.js";import"./data-qa-utils-8be7c726.js";import"./dx-ui-element-de378e9d.js";import"./lit-element-base-af247167.js";import"./nameof-factory-64d95f5b.js";import"./thumb-b78dcc42.js";import"./events-interseptor-eeff27a3.js";import"./popupportal-a6998ee4.js";import"./modalcomponents-74e22511.js";import"./css-classes-f3f8ed66.js";import"./masked-input-3eb5a8b4.js";import"./text-editor-98535492.js";import"./input-ac8f7b19.js";import"./mask-controller-6b09f135.js";import"./disposable-d2c2d283.js";import"./dom-utils-7f5be2f0.js";import"./dx-html-element-pointer-events-helper-0f2b6602.js";class a extends CustomEvent{constructor(e,t,o,r){super(a.eventName,{detail:new c(e,t,o,r),bubbles:!0,composed:!0,cancelable:!0})}}a.eventName=i+".keydown";class l extends CustomEvent{constructor(e){super(l.eventName,{detail:new m(e),bubbles:!0,composed:!0,cancelable:!0})}}l.eventName=i+".keyup";class c{constructor(e,t,o,r){this.Key=e,this.AltKey=t,this.CtrlKey=o,this.Text=r}}class m{constructor(e){this.Key=e}}var h;s.register(a.eventName,(e=>e.detail)),s.register(l.eventName,(e=>e.detail)),function(e){e.ContentOrEditorWidth="contentoreditorwidth",e.ContentWidth="contentwidth",e.EditorWidth="editorwidth"}(h||(h={}));class u extends r{constructor(){super(),this.boundOnDropDownSelectedItemsChangedHandler=this.onDropDownSelectedItemsChanged.bind(this),this.dropDownWidthMode=h.ContentOrEditorWidth,this.filteringEnabled=!1,this.isReadOnly=!1,this.dropDownWidthSourceResizeObserver=new ResizeObserver(this.onDropDownWidthSourceSizeChanged.bind(this))}get useMobileFocusBehaviour(){return t.MobileUI||super.useMobileFocusBehaviour}get shouldProcessFocusOut(){return this.enabled&&!this.isReadOnly}connectedCallback(){super.connectedCallback(),this.observeForDropDownWidthSourceElementSize()}disconnectedCallback(){this.dropDownWidthSourceResizeObserver.disconnect(),super.disconnectedCallback()}updated(e){super.updated(e),e.has("dropDownWidthMode")&&this.prepareDropDownWidth()}onSlotChanged(e){super.onSlotChanged(e);const t=this.getDropDownWidthSourceElement();this.dropDownWidthSourceResizeObserver.observe(t)}processKeyDownServerCommand(e){var t;if(!this.requireSendKeyCommandToServer(e))return super.processKeyDownServerCommand(e);const o=null===(t=this.inputElement)||void 0===t?void 0:t.value;return this.dispatchEvent(new a(e.key,e.altKey,e.ctrlKey||e.metaKey,o)),!0}processKeyUp(e){return e.keyCode!==d.KeyCode.Up&&e.keyCode!==d.KeyCode.Down||this.dispatchEvent(new l(e.key)),!1}onTextInput(e){this.inputElement&&(!this.isDropDownOpen&&e.data&&e.data.length>0&&this.toggleDropDownVisibility(),this.filteringEnabled&&(e.stopPropagation(),this.raiseFieldText()))}onTextChange(e){}onDropDownSelectedItemsChanged(e){e.stopPropagation();const t=e.target;null==t||t.scrollToFocusedItem(!1)}onDropDownWidthSourceSizeChanged(e,t){if(e.length<1||!this.dropDownElement)return;const o=e[0].borderBoxSize[0].inlineSize+"px";this.dropDownElement.desiredWidth=this.dropDownWidthMode===h.EditorWidth?o:null,this.dropDownElement.minDesiredWidth=this.dropDownWidthMode===h.ContentOrEditorWidth?o:null}ensureDropDownElement(){var e;super.ensureDropDownElement(),null===(e=this.dropDownElement)||void 0===e||e.addEventListener(n.eventName,this.boundOnDropDownSelectedItemsChangedHandler)}disposeDropDownElement(){var e;null===(e=this.dropDownElement)||void 0===e||e.removeEventListener(n.eventName,this.boundOnDropDownSelectedItemsChangedHandler),super.disposeDropDownElement()}prepareDropDownWidth(){if(this.isInitialized)switch(this.dropDownWidthSourceResizeObserver.disconnect(),this.dropDownElement&&(this.dropDownElement.desiredWidth=null,this.dropDownElement.minDesiredWidth=null),this.dropDownWidthMode){case h.EditorWidth:case h.ContentOrEditorWidth:this.dropDownWidthSourceResizeObserver.observe(this.getDropDownWidthSourceElement())}}observeForDropDownWidthSourceElementSize(){this.dropDownWidthSourceResizeObserver.disconnect();const e=this.getDropDownWidthSourceElement();e&&this.dropDownWidthSourceResizeObserver.observe(e)}getDropDownWidthSourceElement(){return this}requireSendKeyCommandToServer(e){switch(e.keyCode){case d.KeyCode.Enter:case d.KeyCode.Esc:case d.KeyCode.Up:case d.KeyCode.Down:case d.KeyCode.PageUp:case d.KeyCode.PageDown:return!0;case d.KeyCode.Home:case d.KeyCode.End:return e.ctrlKey||e.metaKey}return!1}}e([p({type:h,attribute:"dropdown-width-mode"})],u.prototype,"dropDownWidthMode",void 0),e([p({type:Boolean,attribute:"filtering-enabled"})],u.prototype,"filteringEnabled",void 0),e([p({type:Boolean,attribute:"is-read-only"})],u.prototype,"isReadOnly",void 0),customElements.define("dxbl-combobox",u);const b={loadModule:function(){},adaptiveDropdownComponents:o};export{u as DxComboBox,b as default};

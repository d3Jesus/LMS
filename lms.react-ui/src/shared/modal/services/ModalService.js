const ModalService = {
    on(event, callback) {
        document.addEventListener(event, (e) => callback(e.detail));
    },
    open(component, id, props = {}) {
        document.dispatchEvent(new CustomEvent('open', { detail: { component, id, props } }));
    },
};

export default ModalService;
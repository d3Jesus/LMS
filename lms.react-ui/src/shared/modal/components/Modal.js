
const Modal = (props) => {
    return (
        <div className="modal right d-block fading" id="modalId" role="dialog" aria-labelledby="modalLabelId">
            <div className="modal-dialog">
                <div className="modal-content">
                    {props.children}
                </div>
            </div>
        </div>
    );
}

export default Modal;
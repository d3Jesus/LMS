import Modal from "../../shared/modal/components/Modal";
import ModalBody from "../../shared/modal/components/ModalBody";
import ModalHeader from "../../shared/modal/components/ModalHeader";
// import ModalFooter from "../../shared/modal/components/ModalFooter";

export default function TestModal(props) {
  return (
    <Modal>
      <ModalHeader>
      <h4 className="modal-title">New Author</h4>
      <button type="button" onClick={props.close} className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </ModalHeader>
      <ModalBody>
        <p>Authors form</p>
      </ModalBody>
      {/* <ModalFooter>
        <button onClick={props.close} className="btn btn-sm btn-primary">Cancel</button>
      </ModalFooter> */}
    </Modal>
  );
}
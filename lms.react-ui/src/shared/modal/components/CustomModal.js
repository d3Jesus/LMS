import Modal from "./Modal";
import ModalBody from "./ModalBody";
import ModalHeader from "./ModalHeader";
import ModalFooter from "./ModalFooter";

export default function TestModal(props) {
  return (
    <Modal>
      <ModalHeader>
      <h4 className="modal-title">Right Sidebar</h4>
      <button type="button" onClick={props.close} className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </ModalHeader>
      <ModalBody>
        <p>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon
          officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3
          wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et.
          Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan
          excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt
          you probably haven't heard of them accusamus labore sustainable VHS.
        </p>
      </ModalBody>
      <ModalFooter>
        <button onClick={props.close} className="btn btn-sm btn-primary">Close Modal</button>
      </ModalFooter>
    </Modal>
  );
}
import { useState, useEffect } from 'react';
import ModalService from '../services/ModalService';

export default function ModalRoot() {

  const [modal, setModal] = useState({});

  /* 
   * useEffect will run when the component renders, which might be more times than you think.
   * 2nd arg = If present, effect will only activate if the values in the list change.
   */
  // useEffect(() => {
  //   ModalService.on('open', ({ component, props }) => {
  //     setModal({
  //       component,
  //       props,
  //       close: value => {
  //         setModal({});
  //       },
  //     });
  //   });
  // }, []);

  useEffect(() => {
    ModalService.on('open', ({ component, id, props }) => {
      setModal({
        component,
        id,
        props,
        close: value => {
          setModal({});
        },
      });
    });
  }, []);

  const ModalComponent = modal.component ? modal.component : null;
  
  return (
    <>
      {ModalComponent && (
        <ModalComponent
          {...modal.props}
          id={modal.id}
          close={modal.close}
          className={ModalComponent ? 'd-block' : ''}
        />
      )}
    </>
  );
}
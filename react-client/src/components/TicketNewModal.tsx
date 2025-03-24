import {forwardRef, useState} from "react";
import {Button, Form, Modal, ModalProps} from "react-bootstrap";
import {ITicket} from "../interfaces/interfaces.ts";

export const TicketNewModal =
  forwardRef<HTMLDivElement, ModalProps>(({ show, handleClose, onConfirm, title }, ref)  => {
    const defaultTicket = {id: 0, title: "", description: "", status: { id: 0, name: '' }, isSelected: true};
    const [formData, setFormData] = useState<ITicket>(defaultTicket);

    const handleConfirm = () => {
      if (onConfirm) {
        onConfirm({id: 0, title: formData.title, description: formData.description, status: {id: 1, name: 'Pending'}, isSelect: true});
      }
      setFormData(defaultTicket);
      handleClose();
    };

    return (
      <>
        <Modal show={show} onHide={handleClose} ref={ref}>
          <Modal.Header closeButton>
            <Modal.Title>{title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Form>
              <Form.Group>
                <Form.Label>Title</Form.Label>
                <Form.Control
                  type="text"
                  value={formData.title}
                  onChange={(e) => setFormData({...formData, title: e.target.value})}
                  placeholder="Enter title"
                />
              </Form.Group>
              <Form.Group className="mt-3">
                <Form.Label>Description</Form.Label>
                <Form.Control as="textarea" rows={5}
                  value={formData.description}
                  onChange={(e) => setFormData({...formData, description: e.target.value})}
                />
              </Form.Group>
            </Form>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Cancel
            </Button>
            <Button variant="primary" onClick={handleConfirm}>
              OK
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    )
  })
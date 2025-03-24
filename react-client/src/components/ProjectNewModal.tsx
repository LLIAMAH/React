import {forwardRef, useState} from "react";
import {ModalProps, Modal, Form, Button} from "react-bootstrap";
import CreatableSelect from "react-select/creatable";

export const ProjectNewModal
    = forwardRef<HTMLDivElement, ModalProps>(({ show, handleClose, onConfirm, title }, ref) => {

    const [formData, setFormData] = useState({name: "", tags: [] as { label: string; value: string }[]});

    const handleConfirm = () => {
        if (onConfirm) {
            onConfirm({name: formData.name, tags: formData.tags.map(tag => tag.value)});
        }
        setFormData({name: "", tags: []});
        handleClose();
    };

    return (
      <Modal show={show} onHide={handleClose} ref={ref}>
          <Modal.Header closeButton>
              <Modal.Title>{title}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
              <Form>
                  <Form.Group>
                      <Form.Label>Название проекта</Form.Label>
                      <Form.Control
                        type="text"
                        value={formData.name}
                        onChange={(e) => setFormData({...formData, name: e.target.value})}
                        placeholder="Введите название"
                      />
                  </Form.Group>
                  <Form.Group className="mt-3">
                      <Form.Label>Теги</Form.Label>
                      <CreatableSelect
                        isMulti
                        onChange={(newValue) =>
                          setFormData({...formData, tags: newValue as { label: string; value: string }[]})}
                        value={formData.tags}
                        placeholder="Добавьте теги"
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
    );
});
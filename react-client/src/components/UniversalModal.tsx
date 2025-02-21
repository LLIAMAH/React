import React, {forwardRef} from "react";
import { Button, Modal } from "react-bootstrap";

interface ModalProps {
    show: boolean;
    handleClose: () => void;
    onConfirm?: () => void;
    title: string;
    children: React.ReactNode;
}

export const UniversalModal
    = forwardRef<HTMLDivElement, ModalProps>(({ show, handleClose, onConfirm, title, children },
                                              ref) => {
    return (
        <Modal show={show} onHide={handleClose} ref={ref}>
            <Modal.Header closeButton>
                <Modal.Title>{title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>{children}</Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Cancel
                </Button>
                {onConfirm && (
                    <Button variant="primary" onClick={onConfirm}>
                        OK
                    </Button>
                )}
            </Modal.Footer>
        </Modal>
    );
});
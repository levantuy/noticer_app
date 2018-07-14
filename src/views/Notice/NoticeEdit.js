import React, { Component } from 'react';
import { FormGroup, Button, Modal, ControlLabel, HelpBlock, FormControl } from 'react-bootstrap';
import axios from 'axios';
import { getToken } from '../../helpers';

class NoticeEdit extends Component {
    constructor(props, context) {
        super(props, context),
            this.state = {
                showModal: false,
                value: '',
                content: '',
                url: ''
            },
        this.open = this.open.bind(this);
        this.close = this.close.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleContentChange = this.handleContentChange.bind(this);
        this.handleUrlChange = this.handleUrlChange.bind(this);
        this.handleSave = this.handleSave.bind(this);
    }

    close() {
        this.setState({ showModal: false });
    };

    open() {
        this.setState({ showModal: true });
    };

    handleSave() {
        if (typeof this.props.onAdd === 'function') {
            this.props.onAdd(
                {
                    NoticeId: this.props.NoticeId,
                    Title: this.state.value,
                    Content: this.state.content,
                    Url: this.state.url
                }
            );
        }        
    };

    getValidationState() {
        const length = this.state.value.length;
        if (length > 6) return 'success';
        else if (length > 4) return 'warning';
        else if (length > 0) return 'error';
        return null;
    };

    handleChange(e) {
        this.setState({ value: e.target.value });
    };

    handleContentChange(e) {
        this.setState({ content: e.target.value });
    };

    handleUrlChange(e) {
        this.setState({ url: e.target.value });
    };

    render() {
        return (<div>
            <Modal show={this.state.showModal} onHide={this.close}>
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <form>
                        <FormGroup validationState={this.getValidationState()}>
                            <ControlLabel>Title</ControlLabel>
                            <FormControl
                                id="title"
                                type="text"
                                value={this.state.value}
                                placeholder="enter text"
                                onChange={this.handleChange}
                            />
                            <FormControl.Feedback />
                            <HelpBlock>Validation is based on string length.</HelpBlock>
                        </FormGroup>
                        <FormGroup>
                            <ControlLabel>Content</ControlLabel>
                            <FormControl id="content" rows="7" componentClass="textarea" placeholder="enter content" value={this.state.content} onChange={this.handleContentChange} />
                        </FormGroup>
                        <FormGroup>
                            <ControlLabel>Url</ControlLabel>
                            <FormControl id="url" type="text" placeholder="enter url" value={this.state.url} onChange={this.handleUrlChange} />
                        </FormGroup>
                    </form>
                </Modal.Body>
                <Modal.Footer>
                    <Button onClick={this.handleSave} className="btn btn-primary">Save</Button>
                    <Button onClick={this.close} className="btn btn-default">Close</Button>
                </Modal.Footer>
            </Modal>
        </div>);
    }
}

export default NoticeEdit;
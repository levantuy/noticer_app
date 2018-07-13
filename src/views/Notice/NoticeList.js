import React, { Component } from 'react';
import NoticeItem from './NoticeItem';
import Notices from './DataNotices';

class NoticeList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            notices: Notices.notices,
        };
    }

    componentDidMount() {
        this.setState({ notices: Notices.notices });
    }

    render() {

        const notices = [
            {
                NoticeId: 1,
                Title: 'Yellow Pail',
                Content: 'On-demand sand castle construction expertise.',
                Url: '#',
            },
            {
                NoticeId: 2,
                Title: 'Yellow Pail',
                Content: 'On-demand sand castle construction expertise.',
                Url: '#',
            },
            {
                NoticeId: 3,
                Title: 'Yellow Pail',
                Content: 'On-demand sand castle construction expertise.',
                Url: '#',
            },
            {
                NoticeId: 4,
                Title: 'Yellow Pail',
                Content: 'On-demand sand castle construction expertise.',
                Url: '#',
            },
        ];

        const noticeComponent = notices.map((notice) => (
            <NoticeItem key={notice.NoticeId}
                NoticeId={'product-' + notice.NoticeId}
                Title={notice.Title}
                Content={notice.Content}
                Url={notice.Url}
            />
        ));

        return (
            <div>
                {noticeComponent}
            </div>
        )
    }
}

export default NoticeList;
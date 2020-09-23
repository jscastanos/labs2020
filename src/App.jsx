import React from 'react';
import Header from './components/header';
import Headline from './components/headline';
import SharedButton from './components/button';
import ListItem from './components/listItem';
import { connect } from 'react-redux';
import { fetchPosts } from './actions';
import './App.scss';

const tempArr = [
  {
    fName: 'Joe',
    lName: 'Doe',
    email: 'joedoe@gmail.com',
    age: 25,
    onlineStatus: true,
  },
];

function App(props) {
  const { posts } = props;

  const configButton = {
    buttonText: 'Get Posts',
    emitEvent: props.fetchPosts,
  };

  return (
    <div className='App'>
      <Header />
      <section className='main'>
        <Headline
          header='Posts'
          desc='Click the button to render posts.'
          tempArr={tempArr}
        />
        <SharedButton {...configButton} />
        {posts.length > 0 && (
          <div>
            {posts.map((post, index) => {
              const { title, body } = post;
              const configListItem = {
                title,
                desc: body,
              };

              return <ListItem key={index} {...configListItem} />;
            })}
          </div>
        )}
      </section>
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    posts: state.posts,
  };
};

export default connect(mapStateToProps, { fetchPosts })(App);

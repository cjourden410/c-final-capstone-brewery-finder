<template>
  <div class="base container-fluid">
    <div class="home mx-auto">
      <h1>Rate {{beer.name}}</h1>
      <form>
        <input type="hidden" v-model="review.beerID"/>
        <div>Name of Beer: {{beer.name}}</div>
        <div>
          Beer Rating (out of 5):
          <input type="number" v-model="review.rating" class="ratingInput" placeholder="1" min="1" max="5" />
          </div>
        <div class="comments">
          Comments:
          </div>
          <textarea type="text" v-model="review.review" class="ratingInput textarea" rows="4" cols="40" placeholder="Enter your comments here." />
          
          <div>
          <button v-on:click.prevent="addReview">Submit</button>
          </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "beer",
  props:{
    id: Number
  },
  data(){
    return{
      beer:{
        id: 0,
        name: "",
      },
      review:{
        id: 0,
        beerID: 0,
        rating: 0,
        review: ""
      }
    }
  },
  methods:{
    getBeer(id){
   let url = `${process.env.VUE_APP_REMOTE_API}/beers/${id}`;
    fetch(url)
    .then(response => {
      response.json()
      .then(json => {
        this.beer = json;
        this.review.beerID = this.beer.id;
      })
    }).catch(err => {console.log(err)});
},
  addReview(){
    let url = `${process.env.VUE_APP_REMOTE_API}/reviews`;
    fetch(url,{
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(this.review)
    }).then(response => {
      if (response.ok){
        response.json().then(json => {
          this.review = json;
          alert(`Review for ${this.beer.name} was added!`)
          this.$router.push({name:'home'});
        });
      }
      else{
        alert(`There was an error: ${response.status}: ${response.statusText}`)
      }
    });
}
  },
  created(){
    this.getBeer(this.$route.params.id);
    this.user = this.$attrs.user;
    // this.addReview();
  }
};
</script>

<style scoped>
.home {
  color: white;
  font-weight: bolder;
  background-color: rgba(100, 100, 100, .9);
  text-align: center;
  align-content: center;
  overflow-y:auto;
  max-width: 1000px;
}
.base {
  align-items: center;
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  /* position: fixed; */
  top: 1;
  left: 0;
  /* background-attachment: fixed; */
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/1.jpg");
  background-attachment: fixed;
  overflow-y:auto;
  padding: 50px
}
@media only screen and (min-width: 1079px) {
  .base {
    position: fixed;
  }
}
.comments{
  display:inline-block;
  vertical-align: middle;
  margin: auto;
}
.textarea{
  width: 50%;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  margin: 3px;
  background-color: gainsboro;
}
</style>
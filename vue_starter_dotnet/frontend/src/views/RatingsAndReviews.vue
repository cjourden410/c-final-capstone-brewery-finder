<template>
  <div class="base">
    <div class="home">
      <h1>Rate {{beer.name}}</h1>
      <form>
        <div>Name of Beer: {{beer.name}}</div>
        <div>
          Beer Rating (out of 5):
          <input type="number" v-model="review.rating" class="ratingInput" placeholder="1" min="1" max="5" />
          </div>
        <div>
          Comments:
          <input type="text" v-model="review.comments" class="ratingInput" placeholder="Enter your comments here." />
          </div>
          <button v-on:click="addReview">Submit</button>
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
        name: "",
        rating: 0,
        comments: ""
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
      })
    }).catch(err => {console.log(err)});
},
  addReview(id){
    let url = `${process.env.VUE_APP_REMOTE_API}/beers/${id}`;
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
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.base {
  width: auto;
  height: 600px;
  background-image: url("../assets/11.jpg");
}
</style>
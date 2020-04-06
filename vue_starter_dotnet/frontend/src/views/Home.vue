<template>
  <div class="home">
    <h1>Home</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
  </div>
</template>

<script>
import auth from '../auth';

export default {
  name: 'home',
  data() {
    return{
      user: null
    }
  },
  methods: {

  },
  created() {
    this.user = auth.getUser();
  }
}
</script>

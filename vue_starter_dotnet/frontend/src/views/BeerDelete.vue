<template>
      <div>
            <h1>Remove this swill from your Beer List</h1>
            <button v-on:click="deleteBeer">Delete Beer</button>
            <router-link tag="button" :to="home">Cancel</router-link>
      </div>

</template>

<script>


export default {

}
</script>

<style scoped>

</style>